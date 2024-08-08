using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Authors.Exceptions;
using Blogs.API.Models.Configurations.TryCatches;
using EFxceptions.Models.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Xeptions;

namespace Blogs.API.Services.Foundations.Authors
{
    public partial class AuthorService
    {
        private delegate ValueTask<Author> ReturningAuthorFunction();
        private delegate IQueryable<Author> ReturningAuthorsFunction();

        private ValueTask<Author> TryCatch(Operation<ValueTask<Author>> operation) =>
            WithTracing(async () =>
            {
                return await WithRollback(async () =>
                {
                    try
                    {
                        return await WithRetry(async () =>
                        {
                            ValidateSecurityRequirement(operation.WithSecurityRoles);

                            return await operation.Execution();
                        },
                        operation.WithRetryOn);

                    }
                    catch (NullAuthorException nullAuthorException)
                    {
                        throw CreateAndLogValidationException(nullAuthorException);
                    }
                    catch (InvalidAuthorException invalidAuthorException)
                    {
                        throw CreateAndLogValidationException(invalidAuthorException);
                    }
                    catch (SqlException sqlException)
                    {
                        var failedAuthorStorageException =
                            new FailedAuthorStorageException(sqlException);

                        throw CreateAndLogCriticalDependencyException(failedAuthorStorageException);
                    }
                    catch (NotFoundAuthorException notFoundAuthorException)
                    {
                        throw CreateAndLogValidationException(notFoundAuthorException);
                    }
                    catch (DuplicateKeyException duplicateKeyException)
                    {
                        var alreadyExistsAuthorException =
                            new AlreadyExistsAuthorException(duplicateKeyException);

                        throw CreateAndLogDependencyValidationException(alreadyExistsAuthorException);
                    }
                    catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
                    {
                        var invalidAuthorReferenceException =
                            new InvalidAuthorReferenceException(foreignKeyConstraintConflictException);

                        throw CreateAndLogDependencyValidationException(invalidAuthorReferenceException);
                    }
                    catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
                    {
                        var lockedAuthorException = new LockedAuthorException(dbUpdateConcurrencyException);

                        throw CreateAndLogDependencyValidationException(lockedAuthorException);
                    }
                    catch (DbUpdateException databaseUpdateException)
                    {
                        var failedAuthorStorageException =
                            new FailedAuthorStorageException(databaseUpdateException);

                        throw CreateAndLogDependencyException(failedAuthorStorageException);
                    }
                    catch (Exception exception)
                    {
                        var failedAuthorServiceException =
                            new FailedAuthorServiceException(exception);

                        throw CreateAndLogServiceException(failedAuthorServiceException);
                    }
                },
                operation.WithRollbackOn);
            },
            operation);

        private async ValueTask<Author> TryCatch(ReturningAuthorFunction returningAuthorFunction)
        {
            try
            {
                return await returningAuthorFunction();
            }
            catch (NullAuthorException nullAuthorException)
            {
                throw CreateAndLogValidationException(nullAuthorException);
            }
            catch (InvalidAuthorException invalidAuthorException)
            {
                throw CreateAndLogValidationException(invalidAuthorException);
            }
            catch (SqlException sqlException)
            {
                var failedAuthorStorageException =
                    new FailedAuthorStorageException(sqlException);

                throw CreateAndLogCriticalDependencyException(failedAuthorStorageException);
            }
            catch (NotFoundAuthorException notFoundAuthorException)
            {
                throw CreateAndLogValidationException(notFoundAuthorException);
            }
            catch (DuplicateKeyException duplicateKeyException)
            {
                var alreadyExistsAuthorException =
                    new AlreadyExistsAuthorException(duplicateKeyException);

                throw CreateAndLogDependencyValidationException(alreadyExistsAuthorException);
            }
            catch (ForeignKeyConstraintConflictException foreignKeyConstraintConflictException)
            {
                var invalidAuthorReferenceException =
                    new InvalidAuthorReferenceException(foreignKeyConstraintConflictException);

                throw CreateAndLogDependencyValidationException(invalidAuthorReferenceException);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedAuthorException = new LockedAuthorException(dbUpdateConcurrencyException);

                throw CreateAndLogDependencyValidationException(lockedAuthorException);
            }
            catch (DbUpdateException databaseUpdateException)
            {
                var failedAuthorStorageException =
                    new FailedAuthorStorageException(databaseUpdateException);

                throw CreateAndLogDependencyException(failedAuthorStorageException);
            }
            catch (Exception exception)
            {
                var failedAuthorServiceException =
                    new FailedAuthorServiceException(exception);

                throw CreateAndLogServiceException(failedAuthorServiceException);
            }
        }

        private IQueryable<Author> TryCatch(ReturningAuthorsFunction returningAuthorsFunction)
        {
            try
            {
                return returningAuthorsFunction();
            }
            catch (SqlException sqlException)
            {
                var failedAuthorStorageException =
                    new FailedAuthorStorageException(sqlException);
                throw CreateAndLogCriticalDependencyException(failedAuthorStorageException);
            }
            catch (Exception exception)
            {
                var failedAuthorServiceException =
                    new FailedAuthorServiceException(exception);

                throw CreateAndLogServiceException(failedAuthorServiceException);
            }
        }

        private AuthorValidationException CreateAndLogValidationException(Xeption exception)
        {
            var authorValidationException =
                new AuthorValidationException(exception);

            this.loggingBroker.LogError(authorValidationException);

            return authorValidationException;
        }

        private AuthorDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var authorDependencyException = new AuthorDependencyException(exception);
            this.loggingBroker.LogCritical(authorDependencyException);

            return authorDependencyException;
        }

        private AuthorDependencyValidationException CreateAndLogDependencyValidationException(Xeption exception)
        {
            var authorDependencyValidationException =
                new AuthorDependencyValidationException(exception);

            this.loggingBroker.LogError(authorDependencyValidationException);

            return authorDependencyValidationException;
        }

        private AuthorDependencyException CreateAndLogDependencyException(
            Xeption exception)
        {
            var authorDependencyException = new AuthorDependencyException(exception);
            this.loggingBroker.LogError(authorDependencyException);

            return authorDependencyException;
        }

        private AuthorServiceException CreateAndLogServiceException(
            Xeption exception)
        {
            var authorServiceException = new AuthorServiceException(exception);
            this.loggingBroker.LogError(authorServiceException);

            return authorServiceException;
        }
    }
}