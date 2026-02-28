import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import AdminDashboardView from '../views/AdminDashboardView.vue'
import ReportView from '../views/ReportView.vue'
import TrackStatusView from '../views/TrackStatusView.vue'
import ProfileView from '../views/ProfileView.vue'
import LoginView from '../views/LoginView.vue'
import HelpView from '../views/HelpView.vue'
import { useAuthStore } from '../stores/auth'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    { path: '/', name: 'home', component: HomeView },
    { path: '/admin', name: 'admin', component: AdminDashboardView },
    { path: '/report', name: 'report', component: ReportView },
    { path: '/track', name: 'track', component: TrackStatusView },
    { path: '/profile', name: 'profile', component: ProfileView },
    { path: '/login', name: 'login', component: LoginView },
    { path: '/help', name: 'help', component: HelpView },
  ],
})

router.beforeEach((to, from, next) => {
  const auth = useAuthStore()

  if (to.name === 'profile' && !auth.isAuthenticated) {
    next({ name: 'login', query: { redirect: to.fullPath } })
    return
  }

  if (to.name === 'login' && auth.isAuthenticated) {
    next({ name: 'profile' })
    return
  }

  next()
})

export default router
