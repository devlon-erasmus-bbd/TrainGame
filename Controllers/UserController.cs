using Microsoft.AspNetCore.Mvc;
using TrainGame.Domain.Models;
using TrainGame.Services;

namespace TrainGame.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    public UserController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetUser()
    {
        try
        {
            var userName = HttpContext.User.Identity.Name;

            // Get the user based on the userName
            User user = _dbContext.Users.SingleOrDefault(u => u.userName == userName);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpPost("New")]
    public IActionResult PostNewUser()
    {
        try
        {
            var userName = HttpContext.User.Identity.Name;

            // Check if the user already exists
            User existingUser = _dbContext.Users.SingleOrDefault(u => u.userName == userName);
            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }

            // Create a new User object with the userName
            var newUser = new User
            {
                userName = userName,
                highScore = 0
            };

            // Add the new user to the Users DbSet
            _dbContext.Users.Add(newUser);

            // Save changes to persist the new user in the database
            _dbContext.SaveChanges();

            return Ok("User added");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpGet("Score")]
    public IActionResult GetUserScore()
    {
        try
        {
            var userName = HttpContext.User.Identity.Name;

            User user = _dbContext.Users.SingleOrDefault(u => u.userName == userName);
            if (user != null)
            {
                int highScore = user.highScore;
                return Ok(highScore);
            }
            else
            {
                return NotFound("No such user " + userName);
                // Just check this log
            }

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    [HttpPost("Score/Update")]
    public IActionResult PostUserScore()//[FromBody] MyModel model)
    {
        // Logic to process the posted data
        // model parameter contains the data sent in the request body

        // Return a response, such as success status or created resource
        var result = new { message = "Data received successfully" };
        return Ok(result);
    }
}