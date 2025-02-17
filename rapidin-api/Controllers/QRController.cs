using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using SkiaSharp.QrCode;
using SkiaSharp.QrCode.Image;

namespace rapidin_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QrController : ControllerBase
    {
        [HttpGet("generate")]
        public IActionResult GenerateQr([FromQuery] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID is required.");
            }

            // Generar los datos del código QR
            var qrCodeData = new QRCodeGenerator().CreateQrCode(id, ECCLevel.L);
            var info = new SKImageInfo(200, 200); // Tamaño de la imagen QR
            using var surface = SKSurface.Create(info);
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White); // Fondo blanco

            // Renderizar el código QR 
            QrCodeExtensions.Render(canvas, qrCodeData, info.Width, info.Height);

            // Convertir a imagen PNG
            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            var imageBytes = data.ToArray();

            // Devolver la imagen como archivo descargable
            return File(imageBytes, "image/png", $"qr_{id}.png");
        }
    }
}
