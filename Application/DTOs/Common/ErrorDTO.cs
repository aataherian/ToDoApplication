using FluentValidation.Results;

namespace ToDoApplication.Application.DTOs;
public class ErrorDTO
{
        public string Property_Name {get;set;}= String.Empty;
        public object? AttemptedValue {get;set;}
        public string	ErrorCode{get;set;}= String.Empty;
        public string 	ErrorMessage{get;set;}= String.Empty;
       
public ErrorDTO()
{
        
}
    
    public ErrorDTO(string PropertyName,  object? AttemptedValue, string ErrorCode, string ErrorMessage)
    {
        this.Property_Name=PropertyName;
        this.AttemptedValue= AttemptedValue;
        this.ErrorCode=ErrorCode;
        this.ErrorMessage=ErrorMessage;
        
    }
    
    
public static List<ErrorDTO> GetErrors(ValidationResult validationResult) 
        {
                List <ErrorDTO> errors = new List<ErrorDTO>();
                
                foreach (var failure in validationResult.Errors)
                {
                        errors.Add(
                                        new ErrorDTO (  
                                                PropertyName:failure.PropertyName,
                                                AttemptedValue:failure.AttemptedValue,
                                                ErrorCode : failure.ErrorCode,
                                                ErrorMessage : failure.ErrorMessage
                                        ));  
                              
                }

                return errors;
        }
}