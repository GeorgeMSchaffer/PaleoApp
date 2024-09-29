using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Backend.Services;
using Backend.Data;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Backend.Controllers;
public class ErrorController
{
    [HttpGet("/error")]
    ///public IActionResult Error() => NotFound();
    public string RequestNotFound()
    {
        return "The requested resource was not found";
    }
}