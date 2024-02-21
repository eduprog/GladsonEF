using GladsonEF.Domain;
using GladsonEF.Infra;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GladsonEF.Controllers;

[ApiController]
[Route("[controller]")]
public class DocumentController : ControllerBase
{
    private readonly DataContext _context;

    public DocumentController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {

        //Vou verificar aqui se o banco de dados não existe e criar através da Migrations, mas não é o melhor lugar, só serve para teste
        if (_context.Database.EnsureCreated())
        {
            // Aqui a gente pode criar um seed para o banco de dados pq os dados foram criados de documentype
            _context.DocumentTypes.Add(new DocumentType("CPF", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("RG", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("CNPJ", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("IE", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Passaporte", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("CNH", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Titulo de Eleitor", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Nascimento", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Casamento", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Óbito", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Divórcio", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de União Estável", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Interdição", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Tutela", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Curatela", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Guarda", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Adoção", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Nada Consta", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Protesto", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Quitação Eleitoral", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do FGTS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do INSS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ICMS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ISS", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ITR", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do IPTU", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do IPVA", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ITBI", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do ITCD", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDT", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CND", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDI", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDL", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDM", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDP", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDH", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDG", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDJ", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDK", true, true, true, 0));
            _context.DocumentTypes.Add(new DocumentType("Certidão de Regularidade do CNDQ", true, true, true, 0));
            _context.SaveChanges();

        };

        var documentTypes = await _context.DocumentTypes.ToListAsync();
        return Ok(documentTypes);
    }
}