namespace WebApiDemo_5Sept19.Controllers
{
    public enum HttpStatusCode
    {

        OK = 200,

        CREATED = 201,

        BAD_REQUEST = 400,

        UNAUTHORIZED = 401,

        FORBIDDEN = 403,

        NOT_FOUND = 404,

        METHOD_NOT_ALLOWED = 405,

        I_AM_A_TEAPOT = 418,

        /**
         * A generic error message, given when an unexpected condition was encountered and no more specific message is suitable.
         */
        INTERNAL_SERVER_ERROR = 500,


        HTTP_VERSION_NOT_SUPPORTED = 505,

    }
}
