import Vue from 'vue'
import Router from 'vue-router'
import MainList from '@/components/MainList'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'MainList',
      component: MainList
    }
  ]
})
