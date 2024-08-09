using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Authors;
using Blogs.API.Models.Authors.Exceptions;

namespace Blogs.API.Services.Foundations.Authors
{
    public partial class AuthorService
    {
        private void ValidateAuthorOnAdd(Author author)
        {
            ValidateAuthorIsNotNull(author);

            Validate(
                (Rule: IsInvalid(author.ID), Parameter: nameof(Author.ID)),
                (Rule: IsInvalid(author.UserID), Parameter: nameof(Author.UserID)),
                (Rule: IsInvalid(author.Name), Parameter: nameof(Author.Name)),
                (Rule: IsInvalid(author.UserName), Parameter: nameof(Author.UserName)),

                (Rule: IsInvalid(author.CreatedDate), Parameter: nameof(Author.CreatedDate)),
                (Rule: IsInvalid(author.UpdatedDate), Parameter: nameof(Author.UpdatedDate)),

                (Rule: IsNotSame(
                    firstDate: author.UpdatedDate,
                    secondDate: author.CreatedDate,
                    secondDateName: nameof(Author.CreatedDate)),
                Parameter: nameof(Author.UpdatedDate)),

                (Rule: IsNotRecent(author.CreatedDate), Parameter: nameof(Author.CreatedDate)));

            // TODO:Logical security validation can go here ...
        }

        private void ValidateAuthorOnModify(Author author)
        {
            ValidateAuthorIsNotNull(author);

            Validate(
                (Rule: IsInvalid(author.ID), Parameter: nameof(Author.ID)),
                (Rule: IsInvalid(author.UserID), Parameter: nameof(Author.UserID)),
                (Rule: IsInvalid(author.Name), Parameter: nameof(Author.Name)),
                (Rule: IsInvalid(author.UserName), Parameter: nameof(Author.UserName)),

                (Rule: IsInvalid(author.CreatedDate), Parameter: nameof(Author.CreatedDate)),
                (Rule: IsInvalid(author.UpdatedDate), Parameter: nameof(Author.UpdatedDate)),

                (Rule: IsSame(
                    firstDate: author.UpdatedDate,
                    secondDate: author.CreatedDate,
                    secondDateName: nameof(Author.CreatedDate)),
                Parameter: nameof(Author.UpdatedDate)),

                (Rule: IsNotRecent(author.UpdatedDate), Parameter: nameof(Author.UpdatedDate)));
        }

        public void ValidateAuthorId(Guid authorId) =>
            Validate((Rule: IsInvalid(authorId), Parameter: nameof(Author.ID)));

        private static void ValidateStorageAuthor(Author maybeAuthor, Guid authorId)
        {
            if (maybeAuthor is null)
            {
                throw new NotFoundAuthorException(authorId);
            }
        }

        private static void ValidateAuthorIsNotNull(Author author)
        {
            if (author is null)
            {
                throw new NullAuthorException();
            }
        }

        private static void ValidateAgainstStorageAuthorOnModify(
            Author inputAuthor, Author storageAuthor)
        {
            Validate(
                (Rule: IsNotSame(
                    firstDate: inputAuthor.CreatedDate,
                    secondDate: storageAuthor.CreatedDate,
                    secondDateName: nameof(Author.CreatedDate)),
                Parameter: nameof(Author.CreatedDate)),

                (Rule: IsSame(
                    firstDate: inputAuthor.UpdatedDate,
                    secondDate: storageAuthor.UpdatedDate,
                    secondDateName: nameof(Author.UpdatedDate)),
                Parameter: nameof(Author.UpdatedDate)));
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        private static dynamic IsSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate == secondDate,
                Message = $"Date is the same as {secondDateName}"
            };

        private static dynamic IsNotSame(
            DateTimeOffset firstDate,
            DateTimeOffset secondDate,
            string secondDateName) => new
            {
                Condition = firstDate != secondDate,
                Message = $"Date is not the same as {secondDateName}"
            };

        private static dynamic IsNotSame(
            Guid firstId,
            Guid secondId,
            string secondIdName) => new
            {
                Condition = firstId != secondId,
                Message = $"Id is not the same as {secondIdName}"
            };

        private dynamic IsNotRecent(DateTimeOffset date) => new
        {
            Condition = IsDateNotRecent(date),
            Message = "Date is not recent"
        };

        private bool IsDateNotRecent(DateTimeOffset date)
        {
            DateTimeOffset currentDateTime =
                this.dateTimeBroker.GetCurrentDateTime();

            TimeSpan timeDifference = currentDateTime.Subtract(date);
            TimeSpan oneMinute = TimeSpan.FromMinutes(1);

            return timeDifference.Duration() > oneMinute;
        }

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidAuthorException = new InvalidAuthorException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidAuthorException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidAuthorException.ThrowIfContainsErrors();
        }
    }
}