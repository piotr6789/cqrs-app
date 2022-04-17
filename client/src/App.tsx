import React from 'react';
import { Route, Routes } from 'react-router-dom';

import Layout from './hoc/layout';
import PostCreator from './components/PostCreator';
import Posts from './components/Posts/Posts';

import { MENU_ROUTES } from './constants/routes/routes';

const App = () => (
  <Layout>
    <Routes>
      <Route path={MENU_ROUTES.POSTS} element={<Posts />} />
      <Route path={MENU_ROUTES.POST_CREATOR} element={<PostCreator />} />
    </Routes>
  </Layout>
);

export default App;
