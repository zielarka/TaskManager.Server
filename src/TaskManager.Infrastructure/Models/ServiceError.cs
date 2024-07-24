using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Infrastructure.Models
{
    public class ServiceError
    {
        public ServiceError(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }

        public ServiceError() { }

        public string Message { get; }

        public int Code { get; }

        public static ServiceError DefaultError => new ServiceError("Wystąpił nieznany błąd. Skontaktuj się z administratorem", 500);

        public static ServiceError ModelStateError(string validationError)
        {
            return new ServiceError(validationError, 998);
        }

        public static ServiceError ForbiddenError => new ServiceError("You are not authorized to call this action.", 401);

        public static ServiceError CustomMessage(string errorMessage)
        {
            return new ServiceError(errorMessage, 997);
        }

        public static ServiceError UserNotFound => new ServiceError("User with this id does not exist", 403);

        public static ServiceError UserFailedToCreate => new ServiceError("Failed to create User.", 995);

        public static ServiceError Canceled => new ServiceError("The request canceled successfully!", 405);

        public static ServiceError NotFound => new ServiceError("The specified resource was not found.", 400);

        public static ServiceError ValidationFormat => new ServiceError("Request object format is not true.", 400);

        public static ServiceError Validation => new ServiceError("One or more validation errors occurred.", 400);

        public static ServiceError PhoneNumberAlreadyInUse => new ServiceError("The phone number is already in use.", 400);

        public static ServiceError SearchAtLeastOneCharacter => new ServiceError("Search parameter must have at least one character!", 400);

        public static ServiceError ServiceProviderNotFound => new ServiceError("Service Provider with this name does not exist.", 502);

        public static ServiceError ServiceProvider => new ServiceError("Service Provider failed to return as expected.", 503);

        public static ServiceError DateTimeFormatError => new ServiceError("Date format is not true. Date format must be like yyyy-MM-dd (2019-07-19)", 406);

        #region Override Equals Operator

        public override bool Equals(object obj)
        {
            var error = obj as ServiceError;

            return Code == error?.Code;
        }

        public bool Equals(ServiceError error)
        {
            return Code == error?.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(ServiceError a, ServiceError b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if ((object)a == null || (object)b == null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ServiceError a, ServiceError b)
        {
            return !(a == b);
        }

        #endregion
    }
}

