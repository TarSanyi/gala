[HttpGet("GetPaged")]
public async Task<IActionResult> GetProducts(int page, int pageSize)
{
    using (var context = new RaktarContext())
    {
        try
        {
            var results = await context.Termekeks
                .OrderBy(t => t.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}