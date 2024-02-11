using Microsoft.AspNetCore.Mvc;

namespace minhaapi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet(Name = "obterDados")]
    public IEnumerable<String> obterDados(string valor, int idade)
    {
        //fazer qualauer coisa aqui 
        if (valor.Equals("mica") && idade==10) 
            yield return "campeao";
        else yield return "perdedor";
    }
}

