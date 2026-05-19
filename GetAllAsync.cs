[HttpGet("GetAll")]
public async Task<IActionResult> GetAll()
{
    using (var context = new RaktarContext())
    {
        try
        {
            var lista = await context.Termekeks.ToListAsync();
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}