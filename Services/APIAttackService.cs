namespace IronDomeSim.Services
{
    public class APIAttackService : IAPIAttackService
    {
        public APIAttackService() { }
        public async Task<string[]> GetAllMisslesImgs()
        {
            var images = new List<byte[]>();
            string[] srcs = Enumerable.Range(1, 15).Select(n => $"../Data/Images/{n}.png").ToArray();
            foreach (var item in srcs)
            {
                images.Add(File.ReadAllBytes(item));
            }
            var base64Images = images.Select(img => Convert.ToBase64String(img)).ToArray();
            return base64Images;
        }
    }
}
