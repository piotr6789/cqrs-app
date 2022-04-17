import * as actionTypes from './actionTypes';

export const changeLanguage = (languageId: any): { type: string, language: any } => {
  localStorage.setItem('language', languageId);

  return {
    type: actionTypes.CHANGE_LANGUAGE,
    language: languageId
  };
};

export const checkLanguage = (): { type: string, language: number } => {
  const languageId = '0';

  if (!languageId) {
    localStorage.setItem('language', '0');

    return {
      type: actionTypes.CHECK_LANGUAGE,
      language: 0
    };
  }
  return {
    type: actionTypes.CHECK_LANGUAGE,
    language: 1
  };
};
