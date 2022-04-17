import React, { FC } from 'react';

import {
  Card, CardContent, Button, TextField
} from '@material-ui/core';

import { useService } from './service';

const PostCreator: FC = (): JSX.Element => {
  const {
    classes, addPostHandler, languageHelper, setAuthorHandler, setContentHandler, setAgeHandler
  } = useService();

  return (
    <Card {...{ className: classes.root }}>
      <CardContent>
        <TextField {...{ variant: 'outlined', label: languageHelper.AUTHOR, onChange: (e) => setAuthorHandler(e.target.value) }} />
        <TextField {...{ variant: 'outlined', label: languageHelper.CONTENT, onChange: (e) => setContentHandler(e.target.value) }} />
        <TextField {...{ variant: 'outlined', label: languageHelper.AGE, onChange: (e) => setAgeHandler(parseInt(e.target.value, 10)) }} />
      </CardContent>
      <Button {...{ onClick: addPostHandler }}>{languageHelper.CREATE}</Button>
    </Card>
  );
};

export default PostCreator;
