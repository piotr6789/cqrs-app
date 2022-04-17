import { useSelector } from 'react-redux';

import { checkLanguage } from '../../../constants/languageHelper/checkLanguageHelper';
import * as LANGUAGE_HELPER from '../../../constants/languageHelper/languageHelper.json';

export const useService = () => {
  const language = useSelector((state:
    { data: any, language: { language: number } }): number => state.language.language);

  const languageHelper = checkLanguage(language, LANGUAGE_HELPER);

  return { languageHelper };
};
