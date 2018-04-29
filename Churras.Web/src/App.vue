<template>
<div>
  <top-header/>
  <main>
    <router-view></router-view>
  </main>
  <bottom-footer/>
</div>
</template>

<script>
import topHeader from "@/components/Header";
import bottomFooter from "@/components/Footer";

export default {
  components: {
    topHeader,
    bottomFooter
  },
  name: "App"
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
/* 

https://coolors.co/223746-087e8b-c0e0ea-ff5a5f-e3d26f

 */
</style>
