import React, { FC, ReactNode } from 'react';

import {
  Button, Menu, MenuItem, Fade
} from '@material-ui/core';

import { useService } from './service';

const NavMenu: FC<{ children: ReactNode }> = ({ children }): JSX.Element => {
  const {
    classes, open, clickBtnHandler, clickLanguageHandler, cancelLanguageHandler,
    languageHelper, anchorEl, language
  } = useService();

  return (
    <>
      <Button {...{ className: classes.root, onClick: clickBtnHandler }}>
        {children}
      </Button>
      <Menu
        {...{
          anchorEl,
          open,
          onClose: cancelLanguageHandler,
          TransitionComponent: Fade
        }}
      >
        <MenuItem
          {...{ onClick: () => clickLanguageHandler(0), selected: Boolean(!language) }}
        >
          {languageHelper.ENGLISH}
        </MenuItem>
        <MenuItem
          {...{ onClick: () => clickLanguageHandler(1), selected: Boolean(language) }}
        >
          {languageHelper.POLISH}
        </MenuItem>
      </Menu>
    </>
  );
};

export default NavMenu;
