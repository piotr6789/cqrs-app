export const checkLanguage = (languageType: number, languageConstantHelper: any) => {
  let languageHelper = null;
  if (languageType === 0) {
    languageHelper = languageConstantHelper.default.ENG;
  } else {
    languageHelper = languageConstantHelper.default.PL;
  }

  return languageHelper;
};
