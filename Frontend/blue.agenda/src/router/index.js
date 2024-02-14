import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'AdicionarContato',
    component: () => import('../views/Cadastro-Contato.vue')
  },
  {
    path: '/Agenda',
    name: 'ListaContatos',
    component: () => import( '../views/Lista-Contato.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
