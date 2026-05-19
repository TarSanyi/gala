[HttpPut]
public IActionResult ModositTermek(Termekek termek)
{
    using (var context = new RaktarContext())
    {
        try
        {
            context.Termekeks.Update(termek);
            context.SaveChanges();
            return Ok("Sikeres módosítás");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}