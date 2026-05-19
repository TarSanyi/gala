[HttpDelete("{id}")]
public async Task<IActionResult> DeleteProduct(int id)
{
    using (var context = new RaktarContext())
    {
        try
        {
            var existingProduct = await context.Termekeks.FirstOrDefaultAsync(t => t.Id == id);

            if (existingProduct == null)
                return NotFound();

            context.Termekeks.Remove(existingProduct);
            await context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}