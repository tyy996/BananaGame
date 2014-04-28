using System;
using Microsoft.Xna.Framework;

namespace BananaTheGame.Terrain
{
    public partial class World
    {
        #region Atmospheric settings
        public static float TimeOfDay { get; set; }
        public static Vector3 DayLight { get; set; }
        public static Vector3 SunPosition = new Vector3(0, 1, 0);
        public static bool IsDayTime;

        public static readonly Vector4 NightColor = Color.Black.ToVector4();
        public static readonly Vector4 SunColor = Color.White.ToVector4();
        public static readonly Vector4 HorizonColor = Color.Black.ToVector4();

        public static readonly Vector4 EveningTint = Color.Red.ToVector4();
        public static readonly Vector4 MorningTint = Color.Gold.ToVector4();
        #endregion

        public static void UpdateDayLight()//move to world later
        {
            TimeOfDay = 12; //locked into day

            if (TimeOfDay > 24)
                TimeOfDay = 0;
            else if (TimeOfDay < 0)
                TimeOfDay = 24;
            //TimeOfDay = MathHelper.Clamp(TimeOfDay, 0, 24);

            if (TimeOfDay <= 12)
            {
                DayLight = Color.White.ToVector3() * TimeOfDay / 12;
            }
            else
            {
                DayLight = Color.White.ToVector3() * (TimeOfDay - 24) / -12;
            }

            DayLight = new Vector3(MathHelper.Clamp(DayLight.X, 0.2f, 1), MathHelper.Clamp(DayLight.Y, 0.2f, 1), MathHelper.Clamp(DayLight.Z, 0.2f, 1));

            // Calculate the position of the sun based on the time of day.
            float x = 0;
            float y = 0;
            float z = 0;

            if (TimeOfDay <= 12)
            {
                y = TimeOfDay / 12;
                x = 12 - TimeOfDay;
            }
            else
            {
                y = (24 - TimeOfDay) / 12;
                x = 12 - TimeOfDay;
            }

            x /= 10;

            SunPosition = new Vector3(-x, z, y);
        }
    }
}
