using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Savorscape.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult MatchToActionResult<A>(this Result<A> result, Func<A, IActionResult> Succ, Func<IError, IActionResult> Fail) =>
           result.IsFailed
               ? Fail(result.Errors.First())
               : Succ(result.Value);
    }
}
