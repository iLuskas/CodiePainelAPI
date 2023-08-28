﻿using Codie.Painel.Application.Model;
using FluentValidation.Results;

namespace Codie.Painel.Application.Services
{
    public class ResultService
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ICollection<ErrorValidation>? Errors { get; set; }

        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService()
            {
                Errors = validationResult.Errors.Select(s =>
                                                            new ErrorValidation()
                                                            {
                                                                Field = s.PropertyName,
                                                                Message = s.ErrorMessage
                                                            }
                                                       ).ToList(),
                IsSuccess = false,
                Message = message
            };
        }

        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>()
            {
                Errors = validationResult.Errors.Select(s =>
                                                            new ErrorValidation()
                                                            {
                                                                Field = s.PropertyName,
                                                                Message = s.ErrorMessage
                                                            }
                                                       ).ToList(),
                IsSuccess = false,
                Message = message
            };
        }

        public static ResultService Fail(string message) => new() { IsSuccess = false, Message = message };
        public static ResultService<T> Fail<T>(string message) => new() { IsSuccess = false, Message = message };

        public static ResultService Ok(string message) => new() { IsSuccess = true, Message = message };
        public static ResultService<T> Ok<T>(T data) => new() { IsSuccess = true, Data = data };
    }

    public class ResultService<T> : ResultService
    {
        public T? Data { get; set; }
    }
}
