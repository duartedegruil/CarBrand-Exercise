namespace CarBrandAPI.Utilities
{
    public static class Constants
    {
        #region Error Messages

        /// <summary>
        /// Message displayed when no information is passed to create the CarBrand
        /// </summary>
        public static readonly string NoInformationPassedToCreateCarBrand = "No information passed to create the Car Brand.";

        /// <summary>
        /// Message displayed when the CarBrand being created already exists in the system
        /// </summary>
        public static readonly string CarBrandAlreadyExists = "CarBrand '{0}' already exists in the system.";

        /// <summary>
        /// Message displayed when no name is passed to retrieve a specific CarBrand
        /// </summary>
        public static readonly string NoNameSpecifiedForCarBrand = "Specify a CarBrand name.";

        /// <summary>
        /// Message displayed when a CarBrand is not found
        /// </summary>
        public static readonly string CarBrandNotFound = "CarBrand '{0}' could not be found.";

        #endregion

        #region Success Messages

        /// <summary>
        /// Message displayed when a CarBrand is successfully created
        /// </summary>
        public static readonly string CarBrandSuccessfullyCreated = "CarBrand '{0}' was successfully created.";

        #endregion
    }
}
