<template>
<v-layout>
    <v-flex xs12 sm6 offset-sm3>
    <card class="ma-3"></card>
    <card class="ma-3"></card>
    <card class="ma-3"></card>
    <card class="ma-3"></card>
    </v-flex>
  </v-layout>
</template>

<script>
import Card from "@/components/Card";

export default {
  components: {
    card: Card
  },
  data() {
    return {
      msg: "Welcome to Your Vue.js App"
    };
  }
};
</script>

<style scoped>

</style>
