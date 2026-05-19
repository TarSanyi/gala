[HttpPost]
public async Task<IActionResult> UjTermek(Termekek termek)
{
    using (var context = new RaktarContext())
    {
        try
        {
            context.Termekeks.Add(termek);
            await context.SaveChangesAsync();
            return Ok("Sikeres hozzáadás");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}