using GladsonEF.Domain;
using GladsonEF.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GladsonEF.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var documentTypes = await context.DocumentTypes.AsNoTracking().ToListAsync();
        return Ok(documentTypes);
    }

    [HttpGet("Id")]

    public async Task<IActionResult> GetById(int id)
    {
        var documentTypes = await context.DocumentTypes.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
        if (documentTypes == null)
            return NotFound();
        return Ok(documentTypes);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var documentType = await context.DocumentTypes.SingleOrDefaultAsync(x => x.Id == id);
        if(documentType == null)
            return NotFound();  
        context.DocumentTypes.Remove(documentType);
        await context.SaveChangesAsync();
        return Ok(documentType);
    }   

}