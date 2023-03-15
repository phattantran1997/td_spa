using Microsoft.AspNetCore.Mvc;
using TD_SPA_Project.Serivce.Implements;
using TD_SPA_Project.Serivce.Interfaces;

namespace TD_SPA_Project.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ICustomerService _customerService;

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _customerService.GetAllCustomers();
        return null;
    }
}

