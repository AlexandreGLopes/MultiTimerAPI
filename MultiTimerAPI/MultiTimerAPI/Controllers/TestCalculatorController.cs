using Microsoft.AspNetCore.Mvc;

namespace MultiTimerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TestCalculatorController : ControllerBase
{
    private readonly ILogger<TestCalculatorController> _logger;

    public TestCalculatorController(ILogger<TestCalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        if(decimal.TryParse(strNumber, out decimal decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        bool isNumber = double.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out double number);
        return isNumber;
    }
}
