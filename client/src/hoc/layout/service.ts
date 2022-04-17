import { Dispatch, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { AnyAction } from 'redux';

import { ClassNameMap } from '@material-ui/core/styles/withStyles';

import * as languageActions from '../../store/actions/index';

import useStyles from './styles';

export const useService = () => {
  const classes: ClassNameMap<'root'> = useStyles();
  const dispatch: Dispatch<AnyAction> = useDispatch();

  useEffect(() => {
    dispatch(languageActions.checkLanguage());
  }, [dispatch]);

  return { classes };
};
