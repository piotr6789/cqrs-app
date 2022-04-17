import React, { FC } from 'react';

import { useContainer } from './container';

const Posts: FC = (): JSX.Element => {
  const { content } = useContainer();

  return content;
};

export default Posts;
