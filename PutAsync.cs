[HttpPut]
public async Task<IActionResult> ModositTermek(Termekek termek)
{
    using (var context = new RaktarContext())
    {
        try
        {
            context.Termekeks.Update(termek);
            await context.SaveChangesAsync();
            return Ok("Sikeres módosítás");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}