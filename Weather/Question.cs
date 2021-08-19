using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherExam
{
    /// <summary>
    /// Represent method to answer question
    /// </summary>
    public class Question : WeatherstackUtil
    {
        /// <summary>
        /// represent response from weather stack api.
        /// </summary>
        private Weatherstack _weatherstack;

        public Question(string accessKey, string zipcode)
        {
            _weatherstack = GetResponse(accessKey, zipcode);
        }

        /// <summary>
        /// Represent question "Should I go outside?"
        /// </summary>
        /// <returns></returns>
        public bool IsRaining()
        {
            var isRaining = false;

            if (_weatherstack?.Current != null)
            {
                isRaining = _weatherstack.Current.Weather_Descriptions.Contains("rain");
            }

            return isRaining;
        }

        /// <summary>
        /// Represent question "Should I wear sunscreen?"
        /// </summary>
        /// <returns></returns>
        public bool ShouldWearSunScreen()
        {
            var wearSunScreen = false;

            if (_weatherstack?.Current != null)
            {
                wearSunScreen = _weatherstack.Current.Uv_Index > 3;
            }

            return wearSunScreen;
        }

        /// <summary>
        /// Represent question "Can I fly my kite?"
        /// </summary>
        /// <returns></returns>
        public bool CanFlyKite()
        {
            var flyKite = false;

            if (_weatherstack?.Current != null)
            {
                flyKite = !IsRaining() && _weatherstack.Current.Wind_Speed > 15;
            }

            return flyKite;
        }
    }
}
