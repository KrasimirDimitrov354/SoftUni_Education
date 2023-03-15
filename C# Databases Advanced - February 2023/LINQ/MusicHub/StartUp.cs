namespace MusicHub;

using System;
using System.Globalization;
using System.Linq;
using System.Text;

using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        DbInitializer.ResetDatabase(context);
        Console.WriteLine(ExportAlbumsInfo(context, 9));
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        var albumsByProducer = context.Albums
            .Where(a => a.ProducerId == producerId)
            .Select(a => new
            {
                a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer!.Name,
                Songs = a.Songs
                    .Select(s => new
                    {
                        s.Name,
                        s.Price,
                        SongWriterName = s.Writer.Name
                    })
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.SongWriterName)
                    .ToArray(),
                AlbumPrice = a.Price
            })
            .ToArray()
            .OrderByDescending(a => a.AlbumPrice);

        StringBuilder output = new StringBuilder();

        foreach (var a in albumsByProducer)
        {
            output.AppendLine($"-AlbumName: {a.Name}");
            output.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
            output.AppendLine($"-ProducerName: {a.ProducerName}");

            output.AppendLine("-Songs:");

            for (int i = 0; i < a.Songs.Length; i++)
            {
                output.AppendLine($"---#{i + 1}");
                output.AppendLine($"---SongName: {a.Songs[i].Name}");
                output.AppendLine($"---Price: {Math.Round(a.Songs[i].Price, 2):f2}");
                output.AppendLine($"---Writer: {a.Songs[i].SongWriterName}");
            }

            output.AppendLine($"-AlbumPrice: {Math.Round(a.AlbumPrice, 2):f2}");
        }

        return output.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        throw new NotImplementedException();
    }
}
