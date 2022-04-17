import React, { FC } from 'react';

import NavBtn from './NavigationItem/NavBtn';
import NavMenu from './NavigationItem/NavMenu';

import { useService } from './service';

import { MENU_ROUTES } from '../../../constants/routes/routes';

const Navigation: FC = (): JSX.Element => {
  const { languageHelper } = useService();

  return (
    <>
      <NavBtn {...{ route: MENU_ROUTES.POSTS }}>{languageHelper.POSTS}</NavBtn>
      <NavBtn {...{ route: MENU_ROUTES.POST_CREATOR }}>
        {languageHelper.NEW_POST}
      </NavBtn>
      <NavMenu>{languageHelper.LANGUAGE}</NavMenu>
    </>
  );
};

export default Navigation;
