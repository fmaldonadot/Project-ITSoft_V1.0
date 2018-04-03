using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ITSoft_V1._0.bus
{
    public class Phone
    {
        private String countryCode;
        private String cityCode;
        private String localCode;
        private String ext = "NA";

        public String getCountryCode()
        {
            return countryCode;
        }
        public void setCountryCode(String countryCode)
        {
            this.countryCode = countryCode;
        }
        public String getCityCode()
        {
            return cityCode;
        }
        public void setCityCode(String cityCode)
        {
            this.cityCode = cityCode;
        }
        public String getLocalCode()
        {
            return localCode;
        }
        public void setLocalCode(String localCode)
        {
            this.localCode = localCode;
        }
        public String getExt()
        {
            return ext;
        }
        public void setExt(String ext)
        {
            this.ext = ext;
        }

        public Phone() { }
        public Phone(String countryCode, String cityCode, String localCode, String ext)
        {
            this.countryCode = countryCode;
            this.cityCode = cityCode;
            this.localCode = localCode;
            this.ext = ext;
        }
        public Phone(String countryCode, String cityCode, String localCode)
        {
            this.countryCode = countryCode;
            this.cityCode = cityCode;
            this.localCode = localCode;
        }

        public override String ToString()
        {
            return countryCode + "|" + cityCode + "|" + localCode + "|" + ext;
        }

    }
}
