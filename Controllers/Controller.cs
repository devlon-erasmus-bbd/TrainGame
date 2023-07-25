using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Services;
using TrainGame.Domain.Models;


namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class Controller : ControllerBase
{

    [HttpGet]
    public String Test()
    {
        return "root controller";
    }
}