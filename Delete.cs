[HttpDelete("{id}")]
public IActionResult DeleteProduct(int id)
{
    using (var context = new RaktarContext())
    {
        try
        {
            var existingProduct = context.Termekeks.FirstOrDefault(t => t.Id == id);

            if (existingProduct == null)
                return NotFound();

            context.Termekeks.Remove(existingProduct);
            context.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}