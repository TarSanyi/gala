[HttpGet("GetAll")]
public IActionResult GetAll()
{
    try
    {
        using var context = new RaktarContext();

        var lista = context.Termekeks
            .Select(t => new TermekDto
            {
                Id = t.Id,
                Nev = t.Nev,
                Leiras = t.Leiras,
                Ar = t.Ar,
                Keszlet = t.Keszlet,
                KategoriaNev = t.Kategoria != null ? t.Kategoria.Nev : null
                // ... további mezők
            })
            .ToList();

        return Ok(lista);
    }
    catch (Exception ex)
    {
        // Éles környezetben inkább logger-t használj és ne add vissza a teljes exceptiont!
        return BadRequest(new { hiba = "Hiba történt az adatok lekérése közben." });
    }
}
