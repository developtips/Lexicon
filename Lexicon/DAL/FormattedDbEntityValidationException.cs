using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Ikco.Data
{
    public class FormattedDbEntityValidationException : DataException
    {
        public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
            base(null, innerException)
        {
        }

        public override string Message
        {
            get
            {
                var innerException = InnerException as DbEntityValidationException;
                if (innerException != null)
                {
                    StringBuilder sb = new StringBuilder();
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = innerException.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(innerException.Message, " The validation errors are: ",
                        fullErrorMessage);

                    sb.AppendLine(exceptionMessage);

                    foreach (var eve in innerException.EntityValidationErrors)
                    {
                        sb.AppendLine(
                            $"- Entity of type \"{eve.Entry.Entity.GetType().FullName}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                        foreach (var ve in eve.ValidationErrors)
                        {
                            sb.AppendLine(
                                $"-- Property: \"{ve.PropertyName}\", Value: \"{eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName)}\", Error: \"{ve.ErrorMessage}\"");
                        }
                    }
                    sb.AppendLine();

                    return sb.ToString();
                }

                return base.Message;
            }
        }
    }
}