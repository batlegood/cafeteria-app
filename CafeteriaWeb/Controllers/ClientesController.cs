using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

public class ClientesController : Controller
{
    private readonly CafeteriaContext _context;

    public ClientesController(CafeteriaContext context)
    {
        _context = context;
    }

    
    public IActionResult Create()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cliente cliente)
    {
        if (!ValidarCedula(cliente.Cedula))
        {
            ModelState.AddModelError("Cedula",
                "Cédula inválida. Solo se permiten 6, 8 o 10 dígitos. Si es de 10, debe comenzar con 1.");
        }

        if (ModelState.IsValid)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            ModelState.Clear();
            ViewBag.Message = "Cliente registrado correctamente.";
        }

        return View();
    }

    private bool ValidarCedula(string cedula)
    {
        if (string.IsNullOrEmpty(cedula) || !cedula.All(char.IsDigit))
            return false;

        if (cedula.Length == 6 || cedula.Length == 8)
            return true;

        if (cedula.Length == 10)
            return cedula.StartsWith("1");

        return false;
    }
}

