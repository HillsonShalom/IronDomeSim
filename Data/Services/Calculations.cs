namespace IronDomeSim.Data.Services
{
    public static class Calculations
    {
        /// <summary>
        /// Get the distance between 2 places by their coordinates
        /// </summary>
        /// <param name="lat1"></param>
        /// <param name="lon1"></param>
        /// <param name="lat2"></param>
        /// <param name="lon2"></param>
        /// <returns></returns>
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // רדיוס כדור הארץ בק"מ
            var dLat = DegreesToRadians(lat2 - lat1);
            var dLon = DegreesToRadians(lon2 - lon1);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }
        private static double DegreesToRadians(double degrees) => degrees * Math.PI / 180;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static double GetResponseTime(double distance, int speed)
        {
            if (speed <= 0 || distance <= 0) return 0;
            return (distance / speed) * 3600;
        }


    }
}
