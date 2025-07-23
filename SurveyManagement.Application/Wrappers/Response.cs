using System;
namespace SurveyManagement.Application.Wrappers
{
    public class SurveyResult<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }

        public SurveyResult() { }

        public SurveyResult(T data, string message = null)
        {
            Data = data;
            Succeeded = true;
            Message = message;
        }

        public static SurveyResult<T> Success(T data, string message = null)
        {
            return new SurveyResult<T>(data, message);
        }

        public static SurveyResult<T> Fail(List<string> errors)
        {
            return new SurveyResult<T> { Succeeded = false, Errors = errors };
        }

        public static SurveyResult<T> Fail(string error)
        {
            return new SurveyResult<T> { Succeeded = false, Errors = new List<string> { error } };
        }
    }

}

