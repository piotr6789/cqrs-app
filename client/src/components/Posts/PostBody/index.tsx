import React, { FC } from 'react';

import { Card, CardContent, Typography } from '@material-ui/core';

import { useService } from './service';

const PostBody: FC<{ author: string, content: string }> = ({ author, content }): JSX.Element => {
  const { classes } = useService();

  return (
    <Card {...{ className: classes.root }}>
      <CardContent>
        <Typography {...{ className: classes.title }}>{author}</Typography>
        <Typography>{content}</Typography>
      </CardContent>
    </Card>
  );
};

export default PostBody;
