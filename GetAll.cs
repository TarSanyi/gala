[HttpGet("GetAll")]
public IActionResult GetAll()
{
    using (var context = new RaktarContext())
    {
        try
        {
            var lista = context.Termekeks.ToList();
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}