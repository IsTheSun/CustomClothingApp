import { createRouter, createWebHistory } from 'vue-router';
import type { RouteRecordRaw } from 'vue-router';
import AccountPage from '../views/AccountPage.vue';
import CatalogPage from '../views/CatalogPage.vue';
import HomePage from '../views/HomePage.vue';
import LoginPage from '../views/LoginPage.vue';
import RegisterPage from '../views/RegisterPage.vue';
import DesignerPage from '../views/DesignerPage.vue';
import CartPage from '../views/CartPage.vue';
const routes: RouteRecordRaw[] = [
  { path: '/', redirect: '/home' },
  { path: '/home', name: 'Home', component: HomePage },
  { path: '/catalog', name: 'Catalog', component: CatalogPage },
  { path: '/account', name: 'Account', component: AccountPage, meta: { requiresAuth: true } },
  { path: '/login', name: 'Login', component: LoginPage },
  { path: '/register', name: 'Register', component: RegisterPage },
  { path: '/designer', name: 'Designer', component: DesignerPage },
  { path: '/cart', name: 'Cart', component: CartPage },
];
const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
});
router.beforeEach((to, from, next) => {
  if (to.meta.requiresAuth) {
    if (localStorage.getItem('token')) {
      next();
    } else {
      next('/login');
    }
  } else {
    next();
  }
});
export default router;
