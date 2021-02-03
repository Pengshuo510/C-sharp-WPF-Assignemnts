//Zalak Patel, Jyoti Mittal, Pengshuo Liu
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JoeAutomotive
{
    class VM : INotifyPropertyChanged
    {
        #region Const declaration
        const int OIL_CHARGES = 26;//decimal
        const int LUBE_CHARGES = 18;
        const int RADIATOR_CHARGES = 30;
        const int TRANSMISSION_CHARGES = 80;
        const int INSPECTION_CHARGES = 15;
        const int MUFFLER_CHARGES = 100;
        const int TIRE_CHARGES = 20;
        const int LABOR_CHARGES = 20;
        const decimal TAX_RATE = 0.06m;
        #endregion

        #region Fields & Properties
        private bool oilChange;
        public bool OilChange
        {
            get { return oilChange; }
            set { oilChange = value; NotifyChange(); }
        }

        private bool lubeJob;
        public bool LubeJob
        {
            get { return lubeJob; }
            set { lubeJob = value; NotifyChange(); }
        }

        private bool radiator;
        public bool Radiator
        {
            get { return radiator; }
            set { radiator = value; NotifyChange(); }
        }

        private bool transmission;
        public bool Transmission
        {
            get { return transmission; }
            set { transmission = value; NotifyChange(); }
        }

        private bool inspection;
        public bool Inspection
        {
            get { return inspection; }
            set { inspection = value; NotifyChange(); }
        }

        private bool muffler;
        public bool Muffler
        {
            get { return muffler; }
            set { muffler = value; NotifyChange(); }
        }

        private bool tire;
        public bool Tire
        {
            get { return tire; }
            set { tire = value; NotifyChange(); }
        }

        private int noOfHours;
        public int NoOfHours
        {
            get { return noOfHours; }
            set { noOfHours = value; NotifyChange(); }
        }

        private decimal partCharges;
        public decimal PartCharges
        {
            get { return partCharges; }
            set { partCharges = value; NotifyChange(); }
        }

        private decimal totalCharges = 0;
        public decimal TotalCharges
        {
            get { return totalCharges; }
            set { totalCharges = value; NotifyChange(); }
        }
        #endregion

        #region Charge
        private decimal OilLubeCharges()
        {
            decimal oilCharge = oilChange ? OIL_CHARGES : 0;
            decimal lubeCharge = lubeJob ? LUBE_CHARGES : 0;
            return oilCharge + lubeCharge;
        }

        private decimal FlushCharges()
        {
            decimal radiatorCharge = radiator ? RADIATOR_CHARGES : 0;
            decimal transmissionCharge = transmission ? TRANSMISSION_CHARGES : 0;
            return radiatorCharge + transmissionCharge;
        }

        private decimal MiscCharges()
        {
            decimal inspectionCharge = inspection ? INSPECTION_CHARGES : 0;
            decimal mufflerCharge = muffler ? MUFFLER_CHARGES : 0;
            decimal tireCharge = tire ? TIRE_CHARGES : 0;
            return inspectionCharge + mufflerCharge + tireCharge;
        }

        private decimal OtherCharges()
        {
            decimal laborCharge = noOfHours * LABOR_CHARGES;//NumHours
            decimal partCharge = partCharges > 0 ? partCharges : 0;
            return laborCharge + partCharge;
        }

        private decimal TaxCharges()
        {
            return (partCharges > 0) ? partCharges * TAX_RATE : 0;
        }

        public decimal Total()
        {
            TotalCharges += OilLubeCharges();
            TotalCharges += FlushCharges();
            TotalCharges += MiscCharges();
            TotalCharges += OtherCharges();
            TotalCharges += TaxCharges();
            return TotalCharges;
        }
        #endregion

        #region Clear
        private void ClearOilLube()
        {
            OilChange = false;
            LubeJob = false;
        }

        private void ClearFlushes()
        {
            Radiator = false;
            Transmission = false;
        }

        private void ClearMisc()
        {
            Inspection = false;
            Muffler = false;
            Tire = false;
        }

        private void ClearOther()
        {
            NoOfHours = 0;
            PartCharges = 0;
        }

        private void ClearTaxAndTotal()
        {
            TotalCharges = 0;
        }

        public void Clear()
        {
            ClearOilLube();
            ClearFlushes();
            ClearMisc();
            ClearOther();
            ClearTaxAndTotal();
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
