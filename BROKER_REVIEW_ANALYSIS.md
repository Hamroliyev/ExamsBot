# Broker Review Analysis - The Standard Compliance

## 🔴 Critical Issues Identified

### 1. StorageBroker.cs - Resource Management Violation
**Issue:** Creating new `StorageBroker` instances inside generic methods
```csharp
public async ValueTask<T> InsertAsync<T>(T @object) where T : class
{
    using var broker = new StorageBroker(this.configuration); // ❌ WRONG
    // ...
}
```
**Problem:**
- Creates new DbContext instances unnecessarily
- Potential connection pool exhaustion
- Should use `this` (injected instance) directly

**Fix:** Use `this` instead of creating new instances

### 2. UserManagementBroker.cs - Dependency Injection Leakage
**Issue:** Creating new `UserManagementBroker` instances inside methods
```csharp
public async ValueTask<User> SelectUserByIdAsync(Guid userId)
{
    var broker = new UserManagementBroker(this.userManagement); // ❌ WRONG
    return await broker.userManagement.FindByIdAsync(userId.ToString());
}
```
**Problem:**
- Violates dependency injection principles
- Unnecessary object creation
- Should use `this.userManagement` directly

**Fix:** Remove all `new UserManagementBroker()` calls, use `this.userManagement` directly

### 3. TelegramBroker.cs - Business Logic Violations
**Issues:**
- ✅ Validation methods (`ValidateMessage`, `ValidateTelegramId`, `ValidateMessageId`) - **ACCEPTABLE** (native library requirements)
- ❌ Exception handling in `HandleUpdateAsync` and `HandlePollingErrorAsync` - **VIOLATION**
- ❌ Business logic (if statements checking eventHandler) - **VIOLATION**

**Problems:**
- Brokers should NOT catch exceptions - let them bubble up
- Business logic (if statements) should be in service layer

**Fix:** Remove try-catch blocks, let exceptions bubble up to services

### 4. StorageBroker Partial Files - Incorrect Using Statements
**Issues:**
- `StorageBroker.StudentAssignments.cs` uses `System.Data.Entity` instead of `Microsoft.EntityFrameworkCore`
- `StorageBroker.Notifications.cs` uses `System.Data.Entity` instead of `Microsoft.EntityFrameworkCore`

**Fix:** Update using statements

### 5. StorageBroker.Result.cs - Business Logic in Broker
**Issue:** Contains Where clauses (business logic)
```csharp
public IQueryable<Result> SelectResultsByExamIdAsync(Guid examId) =>
    SelectAll<Result>().Where(r => r.ExamId == examId); // ❌ Business logic
```
**Problem:** Filtering logic should be in service layer, broker should only provide data access

**Fix:** Remove filtering, return `IQueryable<Result>` and let service layer filter

### 6. StorageBroker.TelegramUsers.cs - Business Logic in Broker
**Issue:** Contains Where clause and FirstOrDefaultAsync (business logic)
```csharp
public async ValueTask<TelegramUser> SelectTelegramUserByTelegramIdAsync(long telegramId) =>
    await this.SelectAllTelegramUsers()
        .Where(user => user.TelegramId == telegramId) // ❌ Business logic
        .AsNoTracking()
        .FirstOrDefaultAsync();
```
**Problem:** Filtering and selection logic should be in service layer

**Fix:** Return `IQueryable<TelegramUser>` and let service layer handle filtering

## ✅ What's Correct

1. **DateTimeBroker** - ✅ Pure, no business logic
2. **LoggingBroker** - ✅ Pure, just wraps ILogger
3. **StorageBroker partial files** - ✅ Use generic methods correctly (except for issues above)
4. **Method naming** - ✅ Follows `Insert[Entity]Async`, `SelectAll[Entity]s` pattern

## 📋 Fix Priority

1. **HIGH:** Fix StorageBroker resource management
2. **HIGH:** Fix UserManagementBroker DI leakage
3. **MEDIUM:** Remove business logic from StorageBroker partial files
4. **MEDIUM:** Remove exception handling from TelegramBroker
5. **LOW:** Fix using statements in partial files

