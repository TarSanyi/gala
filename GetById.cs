[HttpGet("{id}")]
public IActionResult GetById(int id)
{
    using (var context = new RaktarContext())
    {
        try
        {
            var t = context.Termekeks.FirstOrDefault(x => x.Id == id);
            if (t != null)
                return Ok(t);
            return StatusCode(400, "Nincs ilyen termék");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}