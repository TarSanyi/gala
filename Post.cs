[HttpPost]
public IActionResult UjTermek(Termekek termek)
{
    using (var context = new RaktarContext())
    {
        try
        {
            context.Termekeks.Add(termek);
            context.SaveChanges();
            return Ok("Sikeres hozzáadás");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}