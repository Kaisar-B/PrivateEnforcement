using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Results;
public sealed class Result<TResult>
{
    private Result(bool isSuccess, TResult? @value, string? errorMessage)
    {
        IsSuccess = isSuccess;
        ResultData = @value;
        ResponseMessage = errorMessage;
    }

    [MemberNotNullWhen(true, nameof(ResultData))]
    [MemberNotNullWhen(false, nameof(ResponseMessage))]
    public bool IsSuccess { get; }

    [MemberNotNullWhen(true, nameof(ResponseMessage))]
    [MemberNotNullWhen(false, nameof(ResultData))]
    public bool IsFailure => !IsSuccess;
    public string? ResponseMessage { get; set; }
    public TResult? ResultData { get; set; }

    public static Result<TResult> Ok(TResult result) => new(true, result, null);
    public static Result<TResult> Fail(string errorMessage) => new(false, default, errorMessage);
}
